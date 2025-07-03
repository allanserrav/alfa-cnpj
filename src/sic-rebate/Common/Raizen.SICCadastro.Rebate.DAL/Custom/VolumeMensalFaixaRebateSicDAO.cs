using COSAN.Framework.DBUtil;
using COSAN.Framework.Factory;
using Raizen.SICCadastro.Rebate.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Raizen.SICCadastro.Rebate.DAL
{
    /// <summary>
    /// Complemento de VolumeMensalFaixaRebateSicDAO
    /// </summary>
    internal partial class VolumeMensalFaixaRebateSicDAO
    {
        #region Constantes

        public const string C_IBM = "IBM";
        public const string C_CdProduto = "COD_PRODUTO";
        public const string C_NmProduto = "NOME_PRODUTO";
        public const string C_DtPeriodo = "DT_PERIODO";
        public const string C_VlVolume = "VOLUME";

        #endregion Constantes

        #region Queries

        #region Query para Selecionar Volume RBC

        private string querySelecionarVolumeRbc = new StringBuilder()
  .AppendLine(" SELECT ")
        .AppendLine(" C.COD_CLIENTE IBM,")
        .AppendLine(" MA.COD_MATERIAL COD_PRODUTO,")
        .AppendLine(" MA.NOM_MATERIAL NOME_PRODUTO,")
        .AppendLine(" F.DAT_FATURAMENTO DT_PERIODO,")
        .AppendLine(" SUM(NVL(IT.QTD_MATERIAL_FATURADA,0) * CASE WHEN F.COD_TIPO_FATURAMENTO IN ('ZREB') THEN -1 ELSE 1 END) VOLUME")
  .AppendLine(" FROM RBC.CLIENTE C")
       .AppendLine(" JOIN RBC.FATURAMENTO F ON F.COD_CLIENTE_EMISSOR = C.COD_CLIENTE")
       .AppendLine(" JOIN RBC.ITEM_FATURAMENTO IT ON F.NRO_DOCUMENTO_FATURAMENTO = IT.NRO_DOCUMENTO_FATURAMENTO")
       .AppendLine(" JOIN RBC.MATERIAL MA  ON MA.COD_MATERIAL = IT.COD_MATERIAL")
       .AppendLine(" LEFT JOIN RBC.ORDEM_VENDA OV ON OV.NRO_ORDEM_VENDA = IT.NRO_ORDEM_VENDA")
  .AppendLine(" WHERE")
        .AppendLine(" ({0})")
        .AppendLine(" AND TO_CHAR(F.DAT_FATURAMENTO,'YYYYMM') >= '{1}' AND TO_CHAR(F.DAT_FATURAMENTO,'YYYYMM') <= '{2}'")
        .AppendLine(" AND (NVL(TRIM(F.IND_ESTORNO), ' ') <> 'X' OR (F.COD_TIPO_FATURAMENTO IN ('ZREB') AND NVL(TRIM(F.IND_ESTORNO), ' ') = 'X'))")
        .AppendLine(" AND IT.COD_UNIDADE_MEDIDA_VENDA = 'M3'")
        .AppendLine(" AND F.COD_TIPO_FATURAMENTO NOT IN ('ZG2B','ZS10')")
        .AppendLine(" AND COALESCE(OV.COD_TIPO_ORDEM_VENDA,'XXXX') NOT IN ('ZCRE','ZFCO')")
  .AppendLine(" GROUP BY C.COD_CLIENTE, F.DAT_FATURAMENTO, MA.COD_MATERIAL, MA.NOM_MATERIAL")
  .AppendLine("").ToString();

        #endregion Query para Selecionar Volume RBC

        #region Query para SelecionarVolumes por Grupo SIC

        /// <summary>
        /// Selecionar Volumes na base SIC
        /// </summary>
        private string querySelecionarVolumeSic = new StringBuilder()
        .AppendLine("SELECT VM.NR_SEQ_VOLUME_MENSAL_FAIXA_REBATE_SIC")
               .AppendLine(",VM.NR_SEQ_FAIXAREBATE_SIC ")
               .AppendLine(",VM.NR_SEQ_FAIXA_REBATE_HISTORICO_SIC ")
               .AppendLine(",VM.VL_VOLUME_COMPRADO_SIC ")
               .AppendLine(",VM.DT_PERIODO_SIC ")
               .AppendLine(",VM.ST_VOLUME_ENCONTRADO ")
               .AppendLine(",VM.NR_SEQ_REBATE_SIC ")
               .AppendLine(",VM.NR_SEQ_CATEGORIA_SIC ")
               .AppendLine(",VM.DT_GRAVACAO_SIC ")
        .AppendLine(" FROM TB_VOLUME_MENSAL_FAIXA_REBATE_SIC VM ")
        .AppendLine(" WHERE VM.DT_PERIODO_SIC >= '{0}' AND VM.DT_PERIODO_SIC <= '{1}' ")
              .AppendLine(" AND VM.NR_SEQ_FAIXAREBATE_SIC IN ({2})")
          .AppendLine("").ToString();

        #endregion Query para SelecionarVolumes por Grupo SIC

        #region Query para SelecionarVolumes por Grupo SIC (ADITIVO)

        /// <summary>
        /// Selecionar Volumes na base SIC
        /// </summary>
        private string querySelecionarVolumeSicAditivo = new StringBuilder()
          .AppendLine("SELECT VM.NR_SEQ_VOLUME_MENSAL_FAIXA_REBATE_SIC ")
                .AppendLine(",VM.NR_SEQ_FAIXAREBATE_SIC ")
                .AppendLine(",VM.NR_SEQ_FAIXA_REBATE_HISTORICO_SIC ")
                .AppendLine(",VM.VL_VOLUME_COMPRADO_SIC ")
                .AppendLine(",VM.DT_PERIODO_SIC ")
                .AppendLine(",VM.ST_VOLUME_ENCONTRADO ")
                .AppendLine(",VM.NR_SEQ_REBATE_SIC ")
                .AppendLine(",VM.NR_SEQ_CATEGORIA_SIC ")
                .AppendLine(",VM.DT_GRAVACAO_SIC ")
          .AppendLine("FROM  TB_VOLUME_MENSAL_FAIXA_REBATE_SIC VM ")
                .AppendLine("JOIN TB_FAIXA_REBATE_HISTORICO_SIC FH ON FH.NR_SEQ_FAIXA_REBATE_HISTORICO_SIC = VM.NR_SEQ_FAIXA_REBATE_HISTORICO_SIC ")
          .AppendLine("WHERE VM.DT_PERIODO_SIC >= '{0}' AND VM.DT_PERIODO_SIC <= '{1}' ")
                .AppendLine("AND FH.NR_SEQ_REBATE_SIC = {2} ")
          .AppendLine("").ToString();

        #endregion Query para SelecionarVolumes por Grupo SIC (ADITIVO)

        #endregion Queries

        #region Variaveis Privadas

        /// <summary>
        /// Instancia de DebitoRebateSicDAO
        /// </summary>
        private IFaixarebateSicDAO _FaixarebateSicDAO = null;

        /// <summary>
        /// Retorna Instancia de DebitoRebateSicDAO
        /// </summary>
        private IFaixarebateSicDAO faixarebateSicDAOService
        {
            get
            {
                if (_FaixarebateSicDAO == null)
                    _FaixarebateSicDAO = Factory.CreateFactoryInstance().CreateInstance<IFaixarebateSicDAO>("FaixarebateSicDAO");

                return _FaixarebateSicDAO;
            }
        }

        /// <summary>
        /// Instancia de FaixaRebateHistoricoSicDAO
        /// </summary>
        private IFaixaRebateHistoricoSicDAO _FaixaRebateHistoricoSicDAO = null;

        /// <summary>
        /// Retorna Instancia de FaixaRebateHistoricoSicDAO
        /// </summary>
        private IFaixaRebateHistoricoSicDAO faixaRebateHistoricoSicDAOService
        {
            get
            {
                if (_FaixaRebateHistoricoSicDAO == null)
                    _FaixaRebateHistoricoSicDAO = Factory.CreateFactoryInstance().CreateInstance<IFaixaRebateHistoricoSicDAO>("FaixaRebateHistoricoSicDAO");

                return _FaixaRebateHistoricoSicDAO;
            }
        }

        #endregion Variaveis Privadas

        #region Metodos Publicos

        #region Selecionar Selecionar Volume Rbc

        /// <summary>
        /// Seleciona em lote os dados do Volume Comprado RBC (Oracle)
        /// </summary>
        /// <param name="inicio">data inicio</param>
        /// <param name="fim">data fim</param>
        /// <param name="listIBM">lista de IBMs</param>
        /// <param name="listCdSapProduto">lista de códigos produto</param>
        /// <returns>Lista de VolumeRBC</returns>
        public IList<VolumeRbc> SelecionarVolumeRbc(DateTime inicio, DateTime fim, List<string> listIBM)
        {
            IList<VolumeRbc> listVolumeRbc = new List<VolumeRbc>();
            using (DatabaseManager databaseManager = new DatabaseManager("APPSIC"))
            {
                string where = "";
                IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, new VolumeMensalFaixaRebateSic(), out where);

                string whereIbms = string.Empty;
                var qtde = Math.Ceiling(listIBM.Count / 1000M);
                for (int i = 0; i < qtde; i++)
                {
                    whereIbms += string.Concat(i == 0 ? " C.COD_CLIENTE IN " : " OR C.COD_CLIENTE IN ",
                        "('",
                        string.Join("','", listIBM.Skip(1000 * i).Take(1000).ToArray()),
                        "')");
                }

                string newQuery = string.Format(querySelecionarVolumeRbc,
                   whereIbms,
                   string.Concat(inicio.Year, inicio.Month.ToString().PadLeft(2, '0')),
                   string.Concat(fim.Year, fim.Month.ToString().PadLeft(2, '0')));

                using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
                {
                    while (dbDataReader.Read())
                    {
                        listVolumeRbc.Add(PreencherVolumeRbc(dbDataReader));
                    }
                }
                databaseManager.CloseConnection();
            }
            return listVolumeRbc;
        }

        #endregion Selecionar Selecionar Volume Rbc

        #region SelecionarVolumeMensalFaixaPeriodo

        /// <summary>
        /// Selecionar em lote os volumes do periodo para a lista de faixas rebate informada
        /// </summary>
        /// <param name="inicio">data inicio</param>
        /// <param name="fim">data fim</param>
        /// <param name="listNrFaixaRebate">Lista de strings</param>
        /// <returns>Lista de Volumes</returns>
        public IList<VolumeMensalFaixaRebateSic> SelecionarVolumeMensalFaixaPeriodo(DateTime inicio, DateTime fim, List<string> listNrFaixaRebate)
        {
            IList<VolumeMensalFaixaRebateSic> listVolumeMensalFaixaRebateSic = new List<VolumeMensalFaixaRebateSic>();
            using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
            {
                string where = "";
                IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, new VolumeMensalFaixaRebateSic(), out where);

                string newQuery = string.Format(querySelecionarVolumeSic,
                   inicio.ToString("yyyy-MM-dd"),
                   fim.ToString("yyyy-MM-dd"),
                   string.Join(",", listNrFaixaRebate.ToArray()));

                using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
                {
                    while (dbDataReader.Read())
                    {
                        listVolumeMensalFaixaRebateSic.Add(Preencher(dbDataReader));
                    }
                }
                databaseManager.CloseConnection();
            }
            return listVolumeMensalFaixaRebateSic;
        }

        #endregion SelecionarVolumeMensalFaixaPeriodo

        #region SelecionarVolumeMensalFaixaPeriodo (Aditivo)

        /// <summary>
        /// Selecionar em lote os volumes do periodo para a lista de faixas rebate informada(Aditivo)
        /// </summary>
        /// <param name="inicio">data inicio</param>
        /// <param name="fim">data fim</param>
        /// <param name="listNrFaixaRebate">Lista de strings</param>
        /// <returns>Lista de Volumes</returns>
        public IList<VolumeMensalFaixaRebateSic> SelecionarVolumeMensalFaixaPeriodoAditivo(DateTime inicio, DateTime fim, RebateSic rebateSic)
        {
            IList<VolumeMensalFaixaRebateSic> listVolumeMensalFaixaRebateSic = new List<VolumeMensalFaixaRebateSic>();
            using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
            {
                string where = "";
                IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, new VolumeMensalFaixaRebateSic(), out where);

                string newQuery = string.Format(querySelecionarVolumeSicAditivo,
                   inicio.ToString("yyyy-MM-dd"),
                   fim.ToString("yyyy-MM-dd"),
                   rebateSic.NrSeqRebateSic);

                using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
                {
                    while (dbDataReader.Read())
                    {
                        listVolumeMensalFaixaRebateSic.Add(Preencher(dbDataReader));
                    }
                }
                databaseManager.CloseConnection();
            }
            return listVolumeMensalFaixaRebateSic;
        }

        #endregion SelecionarVolumeMensalFaixaPeriodo (Aditivo)

        #region Inserir Lista Transação

        /// <summary>
        /// Incluir Lista VolumeMensalFaixaRebateSic Transacionado
        /// Verifica se já existe VolumeMensal também considerando a faixa, conforme parametro
        /// </summary>
        public void Incluir(List<VolumeMensalFaixaRebateSic> listVolumeMensalFaixaRebateSic, List<FaixarebateSic> listFaixaRebateSic, bool checarFaixas = false)
        {
            List<VolumeMensalFaixaRebateSic> listVolumeInsert = new List<VolumeMensalFaixaRebateSic>();
            Dictionary<int, FaixaRebateHistoricoSic> dictFaixaRebateHistoricoSic = new Dictionary<int, FaixaRebateHistoricoSic>();
            var volumesEncontrados = new List<VolumeMensalFaixaRebateSic>();

            //Fluxo de validação
            foreach (VolumeMensalFaixaRebateSic volume in listVolumeMensalFaixaRebateSic)
            {
                //Verifica se o volume já foi inserido dentro do período
                var _filtro = new VolumeMensalFaixaRebateSic
                {
                    DtPeriodoSic = volume.DtPeriodoSic,
                    NrSeqRebateSic = volume.NrSeqRebateSic
                };
                if (checarFaixas) _filtro.NrSeqFaixarebateSic = volume.NrSeqFaixarebateSic;
                var volumesValidacaoFaixa = this.Selecionar(_filtro, 0, null);

                VolumeMensalFaixaRebateSic volumeValidacaoFaixa = volumesValidacaoFaixa.FirstOrDefault();

                //Loga inconsitência
                if (volumeValidacaoFaixa != null)
                {
                    Console.WriteLine(string.Format(
                        "Não é possível inserir o volume: Periodo {0}, NrFaixaRebate {1}, NrSeqFaixaRebateHistoricoSic {2}, Volume {3}. Este volume já foi inserido!",
                        volumeValidacaoFaixa.DtPeriodoSic.Value.ToString("MM/yyyy"), volumeValidacaoFaixa.NrSeqFaixarebateSic,
                        volumeValidacaoFaixa.NrSeqFaixaRebateHistoricoSic, volumeValidacaoFaixa.VlVolumeCompradoSic));
                    Console.WriteLine("");

                    var volumeEncontrado = volumesValidacaoFaixa
                        .FirstOrDefault(r => !volumesEncontrados.Any(ir => ir.NrSeqVolumeMensalFaixaRebateSic == r.NrSeqVolumeMensalFaixaRebateSic));
                    if (volumeEncontrado != null)
                    {
                        volume.NrSeqVolumeMensalFaixaRebateSic = volumeEncontrado.NrSeqVolumeMensalFaixaRebateSic;
                        volumesEncontrados.Add(volume);
                    }
                    continue;
                }

                //Busca a faixa rebate
                if (!dictFaixaRebateHistoricoSic.ContainsKey(volume.NrSeqFaixarebateSic.Value))
                {
                    FaixarebateSic faixaRebateSic = listFaixaRebateSic.SingleOrDefault(f => f.NrSeqFaixarebateSic == volume.NrSeqFaixarebateSic);
                    if (faixaRebateSic == null)
                        faixaRebateSic = faixarebateSicDAOService.Selecionar(new FaixarebateSic { NrSeqFaixarebateSic = volume.NrSeqFaixarebateSic }, 0, null).Single();

                    FaixaRebateHistoricoSic faixaRebateHistoricoSic = FaixarebateSicToFaixaRebateHistoricoSic(faixaRebateSic);
                    faixaRebateHistoricoSicDAOService.Incluir(faixaRebateHistoricoSic);
                    dictFaixaRebateHistoricoSic.Add(volume.NrSeqFaixarebateSic.Value, faixaRebateHistoricoSic);
                    volume.NrSeqFaixaRebateHistoricoSic = faixaRebateHistoricoSic.NrSeqFaixaRebateHistoricoSic;
                }
                else
                {
                    volume.NrSeqFaixaRebateHistoricoSic = dictFaixaRebateHistoricoSic[volume.NrSeqFaixarebateSic.Value].NrSeqFaixaRebateHistoricoSic;
                }

                //Insere volume na lista
                listVolumeInsert.Add(volume);
            }

            //Fluxo de Inseção - Volume
            using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
            {
                databaseManager.Transaction = databaseManager.BeginTransaction();

                try
                {
                    //Insere Volumes
                    foreach (VolumeMensalFaixaRebateSic volume in listVolumeInsert)
                    {
                        Incluir(volume, databaseManager);
                    }
                    databaseManager.CommitTransaction();
                }
                catch
                {
                    databaseManager.RollbackTransaction();                    
                    throw;
                }
                finally
                {
                    databaseManager.CloseConnection();
                }
            }
        }

        #endregion Inserir Lista Transação

        #endregion Metodos Publicos

        #region Metodos Privados

        #region Metodos Gerais

        /// <summary>
        /// Preenche o objeto VolumeMensalFaixaRebateSic a partir do SafeDataReader.
        /// </summary>
        /// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
        /// <returns>O objeto VolumeMensalFaixaRebateSic preenchido</returns>
        protected VolumeRbc PreencherVolumeRbc(SafeDataReader reader)
        {
            if (reader == null) throw (new ArgumentNullException("reader"));
            VolumeRbc volumeRbc = new VolumeRbc();
            volumeRbc.NrIbmRebateRbc = reader.GetString(C_IBM);
            volumeRbc.CdProdutoRbc = reader.GetString(C_CdProduto);
            volumeRbc.NmProdutoRbc = reader.GetString(C_NmProduto);
            volumeRbc.VlVolumeCompradoRbc = reader.GetNullableDecimal(C_VlVolume);
            volumeRbc.DtPeriodoRbcTexto = reader.GetDateTime(C_DtPeriodo);
            return volumeRbc;
        }

        /// <summary>
        /// Converte objeto FaixarebateSic para FaixaRebateHistoricoSic
        /// </summary>
        /// <param name="entrada">FaixarebateSic</param>
        /// <returns>FaixaRebateHistoricoSic</returns>
        public FaixaRebateHistoricoSic FaixarebateSicToFaixaRebateHistoricoSic(FaixarebateSic entrada)
        {
            return new FaixaRebateHistoricoSic
            {
                DtFimcalculoRebateSic = entrada.DtFimcalculoRebateSic,
                DtIniciocalculoRebateSic = entrada.DtIniciocalculoRebateSic,
                NrSeqCategoriaSic = entrada.NrSeqCategoriaSic,
                NrSeqFaixarebateSic = entrada.NrSeqFaixarebateSic,
                NrSeqGrupoSic = entrada.NrSeqGrupoSic,
                NrSeqRebateSic = entrada.NrSeqRebateSic,
                VlBonificacaoRebateSic = entrada.VlBonificacaoRebateSic,
                VlPercmaximoRebateSic = entrada.VlPercmaximoRebateSic,
                VlPercminimoRebateSic = entrada.VlPercminimoRebateSic,
                VlRecebebonusRebateSic = entrada.VlRecebebonusRebateSic,
                VlVolumemensalRebateSic = entrada.VlVolumemensalRebateSic
            };
        }

        #endregion Metodos Gerais

        #endregion Metodos Privados
    }
}