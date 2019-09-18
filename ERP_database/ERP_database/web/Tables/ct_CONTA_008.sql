﻿CREATE TABLE [web].[ct_CONTA_008] (
    [IdUsuario]                      VARCHAR (50)  NOT NULL,
    [IdEmpresa]                      INT           NOT NULL,
    [IdCtaCble]                      VARCHAR (50)  NOT NULL,
    [IdCentroCosto]                  VARCHAR (200) NOT NULL,
    [pc_Cuenta]                      VARCHAR (500) NOT NULL,
    [IdCtaCblePadre]                 VARCHAR (50)  NULL,
    [EsCtaUtilidad]                  BIT           NOT NULL,
    [IdNivelCta]                     INT           NOT NULL,
    [IdGrupoCble]                    VARCHAR (5)   NOT NULL,
    [gc_GrupoCble]                   VARCHAR (50)  NOT NULL,
    [gc_estado_financiero]           VARCHAR (50)  NOT NULL,
    [gc_Orden]                       INT           NOT NULL,
    [DebitosSaldoInicial]            FLOAT (53)    NOT NULL,
    [CreditosSaldoInicial]           FLOAT (53)    NOT NULL,
    [SaldoInicial]                   FLOAT (53)    NOT NULL,
    [Debitos]                        FLOAT (53)    NOT NULL,
    [Creditos]                       FLOAT (53)    NOT NULL,
    [SaldoDebitosCreditos]           FLOAT (53)    NOT NULL,
    [SaldoDebitos]                   FLOAT (53)    NOT NULL,
    [SaldoCreditos]                  FLOAT (53)    NOT NULL,
    [SaldoFinal]                     FLOAT (53)    NOT NULL,
    [EsCuentaMovimiento]             BIT           NOT NULL,
    [Naturaleza]                     VARCHAR (2)   NOT NULL,
    [SaldoInicialNaturaleza]         FLOAT (53)    NOT NULL,
    [SaldoDebitosCreditosNaturaleza] FLOAT (53)    NOT NULL,
    [SaldoDebitosNaturaleza]         FLOAT (53)    NOT NULL,
    [SaldoCreditosNaturaleza]        FLOAT (53)    NOT NULL,
    [SaldoFinalNaturaleza]           FLOAT (53)    NOT NULL,
    CONSTRAINT [PK_ct_CONTA_008_balances] PRIMARY KEY CLUSTERED ([IdUsuario] ASC, [IdEmpresa] ASC, [IdCtaCble] ASC, [IdCentroCosto] ASC)
);

